// Validate the username
function validateUsername() {
    var username = document.getElementById("username").value;
    if (username == "") {
      alert("Please enter a username");
      return false;
    }
    return true;
  }
  
  // Validate the email address
  function validateEmail() {
    var email = document.getElementById("email").value;
    var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if (!regex.test(email)) {
      alert("Please enter a valid email address");
      return false;
    }
    return true;
  }
  
  // Validate the password
  function validatePassword() {
    var password = document.getElementById("password").value;
    var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]{8,}$/;
    if (!regex.test(password)) {
      alert("Please enter a password that is at least 8 characters long and contains at least one lowercase letter, one uppercase letter, and one number");
      return false;
    }
    return true;
  }
  
  // Validate the form when it is submitted
  function validateForm() {
    if (validateUsername() && validateEmail() && validatePassword()) {
      return true;
    }
    return false;
  }