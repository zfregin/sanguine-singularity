
 if ( navigator.platform.indexOf('Win') != -1 ) {
  window.document.getElementById("wrapper").setAttribute("class", "windows");
} else if ( navigator.platform.indexOf('Mac') != -1 ) {
  window.document.getElementById("wrapper").setAttribute("class", "mac");
}

$(document).ready(function(){
	$("#orderBtn").click(function(){
		getReceipt();
		$("#orderModal").modal();
	});
});

function getReceipt() {
	var totalArray = [];
	var sizeTotal = 0;
	var sizeArray = document.getElementsByName("size")
	for (var i = 0; i < sizeArray.length; i++) {
		if (sizeArray[i].checked) {
			var selectedSize = sizeArray[i].value;
		}
	}
	if (selectedSize === "Personal Pizza") {
		sizeTotal = 6;
	} else if (selectedSize === "Medium Pizza") {
		sizeTotal = 10;
	} else if (selectedSize === "Large Pizza") {
		sizeTotal = 14;
	} else if (selectedSize === "Extra Large Pizza") {
		sizeTotal = 16;
	}
	totalArray.push(sizeTotal, "You Ordered: ", selectedSize);

	console.log(totalArray);
	console.log(selectedSize+" = $"+sizeTotal+".00");
	console.log("size receiptText: "+totalArray[1]+totalArray[2]);
	console.log("subtotal: $"+totalArray[0]+".00");
	getCrust(totalArray);
	getCheese(totalArray);
	getSauce(totalArray);
	getMeat(totalArray);
	getVeggies(totalArray);
	document.getElementById("pizza-size").innerHTML = selectedSize;
	document.getElementById("size-price").innerHTML = "$"+sizeTotal+".00";
	document.getElementById("order-total").innerHTML = "$"+totalArray[0]+".00";
	return totalArray;
}



function getCrust(totalArray) {
	var crustTotal = 0;
	var crustArray = document.getElementsByName("crust");
	for (var i = 0; i < crustArray.length; i++) {
		if (crustArray[i].checked) {
			var selectedCrust = crustArray[i].value;
			// receiptText = receiptText+selectedCrust+"<br>";
		}
	}
	totalArray.push(selectedCrust);
	if (selectedCrust === "Cheese Stuffed Crust") {
		crustTotal = 3;
	} else {
		crustTotal = 0;
	}
	totalArray[0] = (totalArray[0] + crustTotal);
	console.log(selectedCrust+" = $"+crustTotal+".00");
	console.log("crust receiptText: "+totalArray[1]+totalArray[2]+totalArray[3]);
	console.log("subtotal: $"+totalArray[0]+".00");
	console.log(totalArray);
	document.getElementById("selected-crust").innerHTML = selectedCrust;
	document.getElementById("crust-price").innerHTML = "$"+crustTotal+".00";
	return totalArray;
}

function getCheese(totalArray) {
	var cheeseTotal = 0;
	var cheeseArray = document.getElementsByName("cheese");
	for (var i = 0; i < cheeseArray.length; i++) {
		if (cheeseArray[i].checked) {
			var selectedCheese = cheeseArray[i].value;
			// receiptText = receiptText+selectedCheese+"<br>";
		}
	}
	totalArray.push(selectedCheese);
	if (selectedCheese === "Extra Cheese") {
		cheeseTotal = 3;
	} else {
		cheeseTotal = 0;
	}
	totalArray[0] = (totalArray[0] + cheeseTotal);
	console.log(selectedCheese+" = $"+cheeseTotal+".00");
	console.log("crust receiptText: "+totalArray[1]+totalArray[2]+totalArray[3]+totalArray[4]);
	console.log("subtotal: $"+totalArray[0]+".00");
	console.log(totalArray);
	document.getElementById("selected-cheese").innerHTML = selectedCheese;
	document.getElementById("cheese-price").innerHTML = "$"+cheeseTotal+".00";
	return totalArray;
}

function getSauce(totalArray) {
	var sauceArray = document.getElementsByName("sauce");
	for (var i = 0; i < sauceArray.length; i++) {
		if (sauceArray[i].checked) {
			var selectedSauce = sauceArray[i].value;
			// receiptText = receiptText+selectedCheese+"<br>";
		}
	}
	totalArray.push(selectedSauce);
	console.log(selectedSauce+" = $0.00");
	console.log("sauce receiptText: "+totalArray[1]+totalArray[2]+totalArray[3]+totalArray[4]+totalArray[5]);
	console.log("subtotal: $"+totalArray[0]+".00");
	console.log(totalArray);
	document.getElementById("selected-sauce").innerHTML = selectedSauce;
	document.getElementById("sauce-price").innerHTML = "$0.00";
	return totalArray;
}

function getMeat(totalArray) {
	var meatTotal = 0;
	var selectedMeats = [];
	var meatArray = document.getElementsByName("meat");
	for (var i = 0; i < meatArray.length; i++) {
		if (meatArray[i].checked) {
			selectedMeats.push(meatArray[i].value);
			console.log("selected meat item: ("+meatArray[i].value+")");
			// receiptText = receiptText+meatArray[i].value+"<br>";
		}
	}
	totalArray.push(selectedMeats);
	var meatCount = selectedMeats.length;
	if (meatCount > 1) {
		meatTotal = (meatCount - 1);
		// Adds spaces to selected meats for receipt text
		for (var i = 1; i < selectedMeats.length; i++) {
			selectedMeats[i] = " "+selectedMeats[i];
		}
	} else {
		meatTotal = 0;
	}
	totalArray[0] = (totalArray[0] + meatTotal);
	console.log(meatCount+" meat - 1 free meat = "+"$"+meatTotal+".00");
	console.log("meat receiptText: "+totalArray[1]+totalArray[2]+totalArray[3]+totalArray[4]+totalArray[5]+totalArray[6]);
	console.log("Purchase Total: "+"$"+totalArray[0]+".00");
	console.log(totalArray);

	document.getElementById("selected-meat").innerHTML = selectedMeats;
	document.getElementById("meat-price").innerHTML = "$"+meatTotal+".00";
	// return totalArray;
}

function getVeggies(totalArray) {
	var veggieTotal = 0;
	var selectedVeggies = [];
	var veggieArray = document.getElementsByName("veggies");
	for (var i = 0; i < veggieArray.length; i++) {
		if (veggieArray[i].checked) {
			selectedVeggies.push(veggieArray[i].value);
			console.log("selected veggie item: ("+veggieArray[i].value+")");
			// receiptText = receiptText+meatArray[i].value+"<br>";
		}
	}
	totalArray.push(selectedVeggies);
	var veggieCount = selectedVeggies.length;
	if (veggieCount > 1) {
		veggieTotal = (veggieCount - 1);
		for (var i = 1; i < selectedVeggies.length; i++) {
			selectedVeggies[i] = " "+selectedVeggies[i];
		}
	} else {
		veggieTotal = 0;
	}
	totalArray[0] = (totalArray[0] + veggieTotal);
	console.log(veggieCount+" veggie - 1 free veggie = "+"$"+veggieTotal+".00");
	console.log("veggie receiptText: "+totalArray[1]+totalArray[2]+totalArray[3]+totalArray[4]+totalArray[5]+totalArray[6]+totalArray[7]);
	console.log("Purchase Total: "+"$"+totalArray[0]+".00");
	console.log(totalArray);
	document.getElementById("selected-veggies").innerHTML = selectedVeggies;
	document.getElementById("veggies-price").innerHTML = "$"+veggieTotal+".00";
	return totalArray;
}