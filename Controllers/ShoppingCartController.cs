﻿using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCartDao _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCartDao shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            PieDao? selectedPie = _pieRepository.GetPieById(pieId);

            if (selectedPie != null) 
            { 
                _shoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            PieDao? selectedPie = _pieRepository.GetPieById(pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }

            return RedirectToAction("Index");
        }
    }
}
