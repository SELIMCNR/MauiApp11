using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    string color;

    [ObservableProperty]
    ObservableCollection<string> colorItems;

    IConnectivity connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
       ColorItems = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }


    [RelayCommand]
    async Task AddColorAsync()
    {
        if(Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
          await Shell.Current.DisplayAlert("Hata", "İnternet bağlantısı yok", "Tamam"); 
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(Color))
            {
                // Örnek: Veri tabanı ekleme
                await Task.Delay(1); // Simüle edilmiş bir bekleme işlemi
                ColorItems.Add(Color);
                Color = string.Empty;
            }
        }
       
    }

    [RelayCommand]
    void DeleteColor(string colorName)
    {
        if (ColorItems.Contains(colorName))
        {    ColorItems.Remove(colorName);
           
        }
    }



    /*
    string color;
    public string Color
    {
        get => color;
        set
        {
            color = value;
            OnPropertyChanged(nameof(Color));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    */
}
