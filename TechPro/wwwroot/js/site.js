﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// change meet the team to list and display background majors
// products will be topology one and two
const activeTab = () => {
    let currentUrl = window.location.href;
    let currentTab = "";
    let url = new URL(currentUrl);
    let path = url.pathname;

    switch (path) {
        case "/About":
            currentTab = document.getElementById("about");
            currentTab.classList.add("nav-link", "active");
            break;
        case "/Contact":
            currentTab = document.getElementById("contact");
            currentTab.classList.add("nav-link", "active");
            break;
        case "/Product":
            currentTab = document.getElementById("product");
            currentTab.classList.add("nav-link", "active");
            break;
        case "/Services":
            currentTab = document.getElementById("services");
            currentTab.classList.add("nav-link", "active");
            break;
        default:
            currentTab = document.getElementById("home");
            currentTab.classList.add("nav-link", "active");
    }
}

const openForm = () => {
    document.getElementById("myForm").style.display = "block";
}

const closeForm = () => {
    document.getElementById("myForm").style.display = "none";
}

const cartPopUP = () => {
    let element = document.getElementById("cartPopup");
    if (getComputedStyle(element).display === "block") {
        document.getElementById("cartPopup").style.display = "none";
    } else if (getComputedStyle(element).display === "none") {
        document.getElementById("cartPopup").style.display = "block";
    }
}

const cartList = () => {
    let cart = document.getElementById("lblCartCount");
    let cartList = [];
    cart.value = cartList.length;
}
    
