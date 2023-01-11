// Get the button and the body element
var button = document.querySelector('button');
var body = document.querySelector('body');

// Create a function that will be called when the button is clicked
function toggleDarkLight() {
  var currentClass = body.className;
  body.className = currentClass == 'dark-mode' ? 'light-mode' : 'dark-mode';
}

// Add an event listener to the button that calls the toggleDarkLight function
// when the button is clicked
button.addEventListener('click', toggleDarkLight);






// Get the button and all of the paragraph elements
var button = document.querySelector('button');
var paragraphs = document.querySelectorAll('p');

// Create a function that will be called when the button is clicked
function toggleDarkLight() {
  var currentClass = body.className;
  body.className = currentClass == 'dark-mode' ? 'light-mode' : 'dark-mode';

  // Loop through all of the paragraph elements
  for (var i = 0; i < paragraphs.length; i++) {
    // Set the class of each paragraph to match the body
    paragraphs[i].className = body.className;
  }
}

// Add an event listener to the button that calls the toggleDarkLight function
// when the button is clicked
button.addEventListener('click', toggleDarkLight);