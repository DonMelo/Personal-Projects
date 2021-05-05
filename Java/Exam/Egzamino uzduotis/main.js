
function check() {
    var Pavadinimas = document.getElementsByName("Pavadinimas")[0].value;
    var Ingridientai = document.getElementsByName("Ingridientai")[0].value;
    var Nurodymai = document.getElementsByName("Nurodymai")[0].value;
    if (isEmpty(Pavadinimas) || isEmpty(Ingridientai) || isEmpty(Nurodymai)) {
        alert("Visi laukeliai privalo būti užpildyti")

    }
}

function isEmpty(input) {
    if (input == "") {
        return true;
    }
    if (input == undefined) {
        return true;
    }
    return false;
}


function changeColor() {
    document.getElementById("Pavadinimas").style.color = 'green';
    return false;
}

function myFunction() {
    var x = document.getElementById("myDIV");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}
function countLetterA() {

    var str = document.getElementsByName("Nurodymai")[0].value;

    var a, index, len;
    var count = 0;

    for (index = 0, len = str.length; index < len; ++index) {
        a = str.charAt(index);
        if (a == "a" || a == "A") {
            count++;
        }

    }
    console.log("a count: " + count);
}




