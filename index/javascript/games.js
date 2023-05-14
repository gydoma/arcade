fetch('games.json')
  .then(response => response.json())
  .then(games => {
    // loop through the games object
    Object.keys(games).forEach(gameName => {
      const game = games[gameName];
      
    // create a card element
    const card = document.createElement('div');
    card.classList.add('card', 'roundedcornes', 'shadow', 'game-card', 'card-'+game.language);

      
    // create a new <img> element for the rating image
    const ratingImg = document.createElement('img');
    
    // set the src attribute based on the rating value
    if (game.rating > 3.9) {
      ratingImg.src = 'Resources/rating/Full.svg';
    } else if (game.rating > 2.9) {
      ratingImg.src = 'Resources/rating/Half.svg';
    } else {
      ratingImg.src = 'Resources/rating/Empty.svg';
    }
            
    // append the rating image to the game object
    game.ratingImg = ratingImg;

    //'download' if cs/py and 'play' if js
    let buttonname = '';
    if (game.language == 'js')
      {buttonname = 'Play'}
    else {buttonname = 'Download'}
    // file extension name on badge
    let file_ext = '';
    if (game.language == 'js') {
      file_ext = 'web';
    }
    else if (game.language == 'py') {
      file_ext = '.py';
    }
    else if (game.language == 'cs') {
      file_ext = '.exe';
    }
    else {
      file_ext = '404';
    }
    // add the game data to the card
    card.innerHTML = `
          <div class="card-top">
              <div class="rating">
                  <h2>${game.rating}</h2>
              </div>
              <div class="badge">
                  <div class="badge-dot badge-${game.language}"></div>
                  ${file_ext}
              </div>
          </div>
          <h2>${game.name}</h2>
          <p>${game.description}</p>
          <div class="card-filler"></div>
          <div class="card-footer">
              <p class="footer-madeby">made by ${game.by}</p>
              <button class="card-button" onclick="window.location.href = '${game.url}';">${buttonname}</button>
          </div>
    `;
    // add the rating image to the card
    const ratingDiv = card.querySelector('.rating');
    ratingDiv.insertBefore(ratingImg, ratingDiv.firstChild)
    // add the card to the page
    const gamesElement = document.querySelector('.games');
    gamesElement.appendChild(card);
    });
  })
  .catch(error => console.error(error));