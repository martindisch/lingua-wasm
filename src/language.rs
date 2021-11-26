use lingua::Language::{self, English, French, German, Italian};

pub trait ToLanguageCode {
    fn to_language_code(&self) -> u32;
}

impl ToLanguageCode for Option<Language> {
    fn to_language_code(&self) -> u32 {
        match self {
            Some(German) => 1,
            Some(English) => 2,
            Some(French) => 3,
            Some(Italian) => 4,
            _ => 0,
        }
    }
}
