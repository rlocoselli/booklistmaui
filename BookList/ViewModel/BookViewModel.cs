﻿using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BookList.Entities;

namespace BookList.ViewModel
{
    public partial class BookViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command CreateBookBtn { get; }
        public Command ModifyBookBtn { get; }



        public BookViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            this.CreateBookBtn = new Command(BookAddBtnTappedAsync);
            this.ModifyBookBtn = new Command<BookBase>(BookModifyBtnTappedAsync);
        }

        private async void BookAddBtnTappedAsync (object obj)
        {
            try
            {
                await this._navigation.PushAsync(new NewBook());
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void BookModifyBtnTappedAsync(BookBase book)
        {
            try
            {
                await this._navigation.PushAsync(new NewBook(book));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

    }
}
