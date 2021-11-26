using System;
using System.Text;
using Wasmtime;

namespace Lingua
{
    public class Detector : IDisposable
    {
        private const string LibPath = "/home/martin/Projects/lingua-wasm/target/wasm32-unknown-unknown/release/lingua_wasm.wasm";

        private readonly Engine engine;
        private readonly Module module;
        private readonly Linker linker;
        private readonly Store store;
        private readonly Instance instance;

        public Detector()
        {
            engine = new Engine();
            module = Module.FromFile(engine, LibPath);
            linker = new Linker(engine);
            store = new Store(engine);
            instance = linker.Instantiate(store, module);
        }

        public int DetectLanguage(string input)
        {
            var memory = instance.GetMemory(store, "memory");

            var alloc = instance.GetFunction(store, "__alloc");
            var dealloc = instance.GetFunction(store, "__dealloc");
            var detectLanguage = instance.GetFunction(store, "detect_language");

            var utf8Input = Encoding.UTF8.GetBytes(input);
            var offset = (int)alloc.Invoke(store, utf8Input.Length);
            var allocatedSlice = memory.GetSpan(store).Slice(offset);
            utf8Input.AsSpan<byte>().CopyTo(allocatedSlice);

            var languageCode = (int)detectLanguage.Invoke(store, offset, utf8Input.Length);

            dealloc.Invoke(store, offset, utf8Input.Length);

            return languageCode;
        }

        public void Dispose()
        {
            engine.Dispose();
            module.Dispose();
            linker.Dispose();
            store.Dispose();
        }
    }
}
