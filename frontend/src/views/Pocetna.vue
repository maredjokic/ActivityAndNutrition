<template>
  <div>
      <div id="chart">
        <apexchart ref="pie" type="donut" width="380" :options="chartOptions" :series="series"></apexchart>
      </div>
  </div>
</template>

<script>

export default {
    name: 'Pregled',
    computed: {
    },
    data () {
        return {
            series: [44, 55, 13],
            chartOptions: {
                theme: {
                    mode: 'light'
                },
                chart: {
                    width: 380,
                    type: 'donut'
                },
                stroke: {
                    width: 0
                },
                labels: ['Proteini', 'Ugljeni hidrati', 'Masti'],
                responsive: [{
                    breakpoint: 480,
                    options: {
                        chart: {
                            width: 200
                        },
                        legend: {
                            position: 'bottom'
                        }
                    }
                }]
            }
        };
    },
    mounted: function () {
        console.log(this.$refs.pie);
    },
    methods: {
    }
};
</script>

<style>
</style>
