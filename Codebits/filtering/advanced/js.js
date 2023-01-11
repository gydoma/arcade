// Get a reference to the checkboxes
const redCheckbox = document.getElementById("red");
const blueCheckbox = document.getElementById("blue");
const greenCheckbox = document.getElementById("green");

// Attach event listeners to the checkboxes
redCheckbox.addEventListener("click", filterCards);
blueCheckbox.addEventListener("click", filterCards);
greenCheckbox.addEventListener("click", filterCards);

// Define the filterCards function
function filterCards() {
  // Get an array of all the cards
  const cards = document.querySelectorAll(".card");

  // Loop through the cards and show or hide them based on the selected checkboxes
  for (const card of cards) {
    if (redCheckbox.checked && card.classList.contains("red")) {
      card.style.display = "block";
    } else if (blueCheckbox.checked && card.classList.contains("blue")) {
      card.style.display = "block";
    } else if (greenCheckbox.checked && card.classList.contains("green")) {
      card.style.display = "block";
    } else {
      card.style.display = "none";
    }
  }
}
