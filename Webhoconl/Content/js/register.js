
    function btnclick() {
        var username = register.userName.value;
        if (username.length == 0) {
            console.log(username);
            document.getElementById('error-user').innerHTML = "User Error";
        }else {
            document.getElementById('error-user').innerHTML = "Uasdsadsad";
        }
    }   