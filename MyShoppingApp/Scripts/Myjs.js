function myClick(para) {
    // alert("" + para.toString());


    var url = "Index?SearchedString=" + para;
    var controllerName = (window.location.href).toString();

 
    
    if (controllerName.includes("Home")) {
     //   alert("-" + url);
        window.location.href = url;
    }
    else {
     //   alert("+"+url);
        
        window.location.href = "Home/" + url;
    }
}


function AddToCart(itemId) {
    alert(itemId.toString());
    

}