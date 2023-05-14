<div style="height: auto; width:100%">
  <canvas id="myChart"></canvas>
</div>

<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>

<script>
const ctx = document.getElementById('myChart').getContext('2d');

const gradient = ctx.createLinearGradient(0, 0, 0, 400);
gradient.addColorStop(0, 'rgba(255, 189, 18, 1)');
gradient.addColorStop(1, 'rgba(255, 255, 255, 1)');

new Chart(ctx, {
  type: 'line',
  data: {
    labels: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
    datasets: [{
      label: "",
      data: [0, 0, 110, 133, 51, 69, 10],
      borderWidth: 3,
      borderColor: 'rgba(0, 0, 0, 1)',
      backgroundColor: gradient,
      pointRadius: 0,
      pointBackgroundColor: 'rgba(249, 90, 44, 0.75)',
      pointBorderColor: 'rgba(0, 0, 0, 1)',
      pointHoverRadius: 10,
      pointHoverBorderColor: 'rgba(0, 0, 0, 1)',
      pointHoverBorderWidth: 2,
      pointHitRadius: 20,
    }]
  },
  options: {
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true,
          display: false
        },
        gridLines: {
          display: false,
          drawBorder: false
        }
      }],
      xAxes: [{
        ticks: {
          beginAtZero: true,
          display: false
        },
        gridLines: {
          display: false,
          drawBorder: false
        }
      }]
    },
    legend: {
       display: false
    },
    responsive: true,
    hover: {
      mode: 'nearest',
      intersect: true
    },
    tooltips: {
      intersect: false,
      mode: 'index',
      position: 'nearest'
    },
    annotation: {
      annotations: [{
        type: 'line',
        mode: 'vertical',
        scaleID: 'x-axis-0',
        value: 'Green',
        borderColor: 'rgba(0, 0, 0, 0.5)',
        borderWidth: 1,
        borderDash: [3, 3],
        label: {
          enabled: false,
          content: 'Vertical line'
        }
      }]
    },
    onHover: function(event, chartElement) {
      event.target.style.cursor = chartElement[0] ? 'pointer' : 'default';
    },
    onHover: function(event, chartElement) {
      if (chartElement.length > 0) {
        const dataIndex = chartElement[0]._index;
        const datasetIndex = chartElement[0]._datasetIndex;
        const dataset = this.data.datasets[datasetIndex];
        dataset.pointRadius[dataIndex] = 10;
        dataset.pointHoverRadius[dataIndex] = 10;
        chartElement[0]._model.radius = 10;
        chartElement[0]._model.hoverRadius = 10;
        chartElement[0]._model.backgroundColor = 'rgba(255, 205, 86, 1)';
        chartElement[0]._model.borderColor = 'rgba(0, 0, 0, 1)';
        chartElement[0]._model.borderWidth = 2;
      }
      this.update();
    },
    onClick: function(event, chartElement) {
      if (chartElement.length > 0) {
        const dataIndex = chartElement[0]._index;
        const datasetIndex = chartElement[0]._datasetIndex;
        const dataset = this.data.datasets[datasetIndex];
        dataset.pointRadius[dataIndex] = 10;
        dataset.pointHoverRadius[dataIndex] = 10;
        chartElement[0]._model.radius = 10;
        chartElement[0]._model.hoverRadius = 10;
        chartElement[0]._model.backgroundColor = 'rgba(255, 205, 86, 1)';
        chartElement[0]._model.borderColor = 'rgba(0, 0, 0, 1)';
        chartElement[0]._model.borderWidth = 2;
      }
      this.update();
    }
  }
});

</script>