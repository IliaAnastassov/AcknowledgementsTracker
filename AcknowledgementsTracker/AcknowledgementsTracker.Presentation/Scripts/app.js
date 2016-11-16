loginFunctions = {
    HideInput: function HideInput(errorLabel, usernameTxtbox, passwordTxtbox) {
        if (errorLabel !== null || usernameTxtbox !== null || passwordTxtbox !== null) {
            document.getElementById(errorLabel).style.display = 'none';
            document.getElementById(usernameTxtbox).style.display = 'none';
            document.getElementById(passwordTxtbox).style.display = 'none';
        }
    }
};