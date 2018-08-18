﻿using StoreReactNET.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StoreReactNET.Models.ViewModels
{
    public class ClickedProductViewModel : ProductViewModel
    {
        public List<List<string>> ProductDetailsList { get; set; }
        public ClickedProductViewModel(Products Product) : base(Product)
        {
            this.ProductDetailsList = new List<List<string>>();
            try
            {
                PropertyInfo[] properties = Product.ProductDetailsNavigation.GetType().GetProperties();
                foreach (var p in properties)
                {

                    var value = p.GetValue(Product.ProductDetailsNavigation, null);
                    if (value != null)
                    {
                        try
                        {
                            var temp = new List<string>();
                            temp.Add(Singleton.FiltersClickedProductName[p.Name]);
                            temp.Add(value.ToString());
                            this.ProductDetailsList.Add(temp);
                        }
                        catch (Exception) { }
                    }
                }
            }
            catch (Exception) { }
            


        }
    }
}
