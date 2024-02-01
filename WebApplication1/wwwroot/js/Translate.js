document.addEventListener("DOMContentLoaded", function () {
    googleTranslateElementInit();
});

function googleTranslateElementInit() {
    new google.translate.TranslateElement(
        { pageLanguage: 'en' },
        'google_translate_element'
    );
}