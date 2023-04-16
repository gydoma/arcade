<div style="height: auto; width:35vw">
  <canvas id="myChart"></canvas>
</div>

<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>

<script>
  const ctx = document.getElementById('myChart');

  new Chart(ctx, {
    type: 'line',
    data: {
      labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
      datasets: [{
        label: "",
        data: [12, 19, 3, 5, 2, 3],
        borderWidth: 1,
        backgroundColor: '#FFBD12',
      }]
    },
    options: {
      scales: {
        y: {
          beginAtZero: true
        }
      },
      legend: {
         display: false
      },
      responsive: true
    },

  });
</script>