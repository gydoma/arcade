const numbers = [1, 2, 3, 4, 5];
const list = document.createElement('ul');

const evenNumbers = numbers.filter(number => number % 2 === 0);

evenNumbers.forEach(number => {
  const listItem = document.createElement('li');
  listItem.textContent = number;
  list.appendChild(listItem);
});

document.body.appendChild(list);