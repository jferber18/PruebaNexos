function liveSearch() {

    let cards = document.querySelectorAll('.searchBar-option')
    let search_query = document.getElementById("InputBuscar").value;

    //Use innerText if all contents are visible
    //Use textContent for including hidden elements
    for (var i = 0; i < cards.length; i++) {
        if (cards[i].textContent.toLowerCase()
            .includes(search_query.toLowerCase())) {
            //cards[i].classList.remove("is-hidden");
            cards[i].style.display = "";
        } else {
            //cards[i].classList.add("is-hidden");
            cards[i].style.display = "none";
        }
    }
}

