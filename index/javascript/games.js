fetch('games.json')
  .then(response => response.json())
  .then(games => {
    // loop through the games object
    Object.keys(games).forEach(gameName => {
      const game = games[gameName];
      
      // create a card element
      const card = document.createElement('div');
      card.classList.add('card', 'roundedcornes', 'shadow');
      
      // add the game data to the card
      card.innerHTML = `
        <h2>${game.name}</h2>
        <p class="by">${game.by}</p>
        <p class="rating">${game.rating}</p>
        <p class="language">${game.language}</p>
        <p class="engine">${game.engine}</p>
        <p class="updated">${game.updated}</p>
      `;
      
      // add the card to the page
      const gamesElement = document.querySelector('.games');
      gamesElement.appendChild(card);
    });
  })
  .catch(error => console.error(error));