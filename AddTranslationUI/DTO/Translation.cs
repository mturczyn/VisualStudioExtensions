﻿using AddTranslationUI.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace AddTranslationUI
{
    class Translation : BaseObservable
    {
        private readonly Dictionary<CultureInfo, string> _translations = new Dictionary<CultureInfo, string>();

        public ObservableCollection<CultureInfo> AvailableTranslations { get; } = new ObservableCollection<CultureInfo>();

        private CultureInfo _selectedCultureInfo;
        public CultureInfo SelectedCultureInfo 
        { 
            get => _selectedCultureInfo;
            set
            {
                if (!SetPropertyAndRaise(value, ref _selectedCultureInfo, nameof(SelectedCultureInfo))) return;
                SelectedTranslationText = _translations[value];
            }
        }

        private string _selectedTranslationText;
        public string SelectedTranslationText
        { 
            get => _selectedTranslationText;
            set => SetPropertyAndRaise(value, ref _selectedTranslationText, nameof(SelectedTranslationText));
        }
         
        public bool AddTranslation(CultureInfo ci, string translationText)
        {
            if (_translations.ContainsKey(ci))
            {
                return false;
            }
            _translations.Add(ci, translationText);
            AvailableTranslations.Add(ci);
            return true;
        }

        public void RemoveTranslation(CultureInfo ci)
        {
            _translations.Remove(ci);
            AvailableTranslations.Remove(ci);
        }
    }
}
