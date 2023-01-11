// Get a reference to the slider
const slider = document.getElementById("rating-slider");

// Attach an event listener to the slider
slider.addEventListener("input", filterCards);

// Define the filterCards function
function filterCards() {
  // Get an array of all the cards
  const cards = document.querySelectorAll(".card");

  // Loop through the cards and show or hide them based on the selected rating
  for (const card of cards) {
    if (card.dataset.rating === slider.value) {
      card.style.display = "block";
    } else {
      card.style.display = "none";
    }
  }
}