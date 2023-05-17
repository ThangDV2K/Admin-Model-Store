var ctx = document.getElementById('myChart').getContext('2d');
var chart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
        datasets: [
            {
                label: 'Marvel',
                data: [12, 19, 3, 5, 2, 8],
                borderColor: 'rgba(255, 99, 132, 1)',
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderWidth: 3
            },
            {
                label: 'DC',
                data: [4, 16, 10, 18, 8, 16],
                borderColor: 'rgba(54, 162, 235, 1)',
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderWidth: 3
            },

            {
                label: 'DaragolBall',
                data: [2, 14, 9, 13, 20, 11],
                borderColor: '#FF9933',
                backgroundColor: '#FF9933',
                borderWidth: 3
            }
        ]
    },
    options: {
        responsive: true,
        title: {
            display: true,
            text: 'Sales Report'
        },
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});
