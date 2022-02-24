fn main() {
    unsafe {
        let input = "Well that's quite nice, isn't it? Should be quite easy.";

        let ptr = lingua_wasm::__alloc(input.len());
        ptr.copy_from(input.as_ptr(), input.len());

        let language = lingua_wasm::detect_language(ptr, input.len());
        println!("Detected {}", language);

        lingua_wasm::__dealloc(ptr, input.len());
    }
}
