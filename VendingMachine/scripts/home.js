$(document).ready(function (){
    loadItems();
    var moneyIn = 0.00;
    var itemNumber;
    document.getElementById("displayIn").innerHTML = moneyIn;
    //below .click functions just add money to the screen and the money in var
    $('#addDollar').click(function (event) {
        moneyIn = moneyIn + 1.00;
        document.getElementById("displayIn").innerHTML = moneyIn.toFixed(2)
        return moneyIn;
    })
    $('#addQuarter').click(function (event) {
        moneyIn = moneyIn + .25;
        document.getElementById("displayIn").innerHTML = moneyIn.toFixed(2)
        return moneyIn;
    })

    $('#addDime').click(function (event) {
        moneyIn = moneyIn + .10;
        document.getElementById("displayIn").innerHTML = moneyIn.toFixed(2)
        return moneyIn;
    })

    $('#addNickle').click(function (event) {
        moneyIn = moneyIn + .05;
        document.getElementById("displayIn").innerHTML = moneyIn.toFixed(2)
        return moneyIn;
    })

    $('.item').click(function() {
        console.log($(this.id));
        var x = this.id;
        var itemNumber = x;
        document.getElementById("itemNumber").value = this.id;
        return itemNumber;
});
//mod is used in the below function to split out the diffrent coin types
$('#returnChange').click(function(){
    //I was getting a weird error where it was sometimes adding 
    //millions of a cent to the end after doing some searching as to why i decieded that it would 
    //be easier to just round it off
    var modQuarters = (moneyIn % .25).toFixed(2);
    var quarters = ((moneyIn - modQuarters)/.25).toFixed(2);
    var modDimes = (modQuarters %.10).toFixed(2);
    var dimes = ((modQuarters - modDimes)/.10).toFixed(2);
    var nickels = (modDimes/.05).toFixed(2);
    moneyIn = 0.00;
    document.getElementById("displayIn").innerHTML = moneyIn.toFixed(2)
    document.getElementById("changeOut").value = "Quarters: " + Math.round(quarters) + " Dimes: "+
    Math.round(dimes)+" Nickels: "+ Math.round(nickels);
    document.getElementById("message").value = "Hello!";
    document.getElementById("itemNumber").value = "";
})
//reduces the quantity of an item by 1 and returns the remaining change 
$('#makePurchase').click(function(){
    var quarters = 0;
    var dimes = 0;
    var nickels = 0;
    var itemHolder = document.getElementById("itemNumber").value;
    $.ajax({
        type:'GET',
        url:`http://localhost:8080/money/${moneyIn}/item/${itemHolder}`,
        headers:{
            "Accept": "application/json",
            "Content-type" : "application/json"
        },
        success:function(data){
            loadItems();
            quarters = data.quarters;
            dimes = data.dimes;
            nickels = data.nickels;
            document.getElementById("message").value = "Thanks!!";
            document.getElementById("changeOut").value = "Quarters: " + quarters + " Dimes: "+
            dimes+" Nickels: "+ nickels;
            moneyIn = 0;
            document.getElementById("displayIn").innerHTML = moneyIn.toFixed(2)
            },
            error: function(data){
                console.log(data);

                var message = data.responseJSON.message;
                console.log(message);
                document.getElementById("message").value = message;
            }
    })
})
})
//populates the 3 by 3 grid when the the page loads 
function loadItems(){
    //clearItems();
    $.ajax({ 
        type:'GET',
        url: 'http://localhost:8080/items',
        success: function(data, status) {
         
            $.each(data,function(index,item){
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var c = document.getElementById(id).children;
               //var c =  $(`#${id}`);
               console.log(c);
                c[0].innerText = (id);
                c[1].innerText = (name);
                c[2].innerText = (price);
                c[3].innerText = (quantity);   
            })
        }
    })
}