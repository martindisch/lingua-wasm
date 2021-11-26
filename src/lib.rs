use lingua::Language::{English, French, German, Italian};
use lingua::LanguageDetectorBuilder;
use std::{slice, str};

use language::ToLanguageCode;

mod interfacing;
mod language;

pub use interfacing::{__alloc, __dealloc};

/// Detects the language of the given UTF-8 string, returning a language code.
///
/// The caller is responsible for using [`__dealloc`] to free the allocated
/// memory of the input string.
#[no_mangle]
pub fn detect_language(ptr: *const u8, len: usize) -> u32 {
    let input =
        unsafe { str::from_utf8_unchecked(slice::from_raw_parts(ptr, len)) };

    let detector = LanguageDetectorBuilder::from_languages(&[
        German, English, French, Italian,
    ])
    .with_preloaded_language_models()
    .build();
    let detected_language = detector.detect_language_of(input);

    detected_language.to_language_code()
}
