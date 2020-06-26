<template>
  <div>
      <v-tabs
        v-model="tab"
        background-color="primary"
        dark
        flat
      >
        <v-tab
          v-for="item in items"
          :key="item.tab"
        >
          {{ item.tab }}
        </v-tab>
      </v-tabs>

      <v-tabs-items v-model="tab">
        <v-tab-item
          v-for="item in items"
          :key="item.tab"
        >
          <v-card flat>
            <div v-show="item.tab === 'Pregled'" id="chart">
                <apexchart ref="pie" type="donut" width="380" :options="chartOptions" :series="series"></apexchart>
            </div>
            <div v-show="item.tab === 'Ishrana'">
                <v-data-table
                :headers="headers"
                :items="desserts"
                :items-per-page="5"
                class="elevation-1"
              ></v-data-table>
            </div>
          </v-card>
        </v-tab-item>
      </v-tabs-items>
  </div>
</template>

<script>

export default {
    name: 'Pregled',
    computed: {
    },
    data () {
        return {
            tab: null,
            items: [
                { tab: 'Ishrana', content: 'Tab 1 Content' },
                { tab: 'Aktivnost', content: 'Tab 2 Content' },
                { tab: 'Pregled', content: 'Tab 3 Content' }
            ],
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
            },
            headers: [
                {
                    text: 'Dessert (100g serving)',
                    align: 'start',
                    sortable: false,
                    value: 'name'
                },
                { text: 'Calories', value: 'calories' },
                { text: 'Fat (g)', value: 'fat' },
                { text: 'Carbs (g)', value: 'carbs' },
                { text: 'Protein (g)', value: 'protein' },
                { text: 'Iron (%)', value: 'iron' }
            ],
            desserts:
            [
                {
                    name: 'Frozen Yogurt',
                    calories: 159,
                    fat: 6.0,
                    carbs: 24,
                    protein: 4.0,
                    iron: '1%'
                },
                {
                    name: 'Ice cream sandwich',
                    calories: 237,
                    fat: 9.0,
                    carbs: 37,
                    protein: 4.3,
                    iron: '1%'
                },
                {
                    name: 'Cupcake',
                    calories: 305,
                    fat: 3.7,
                    carbs: 67,
                    protein: 4.3,
                    iron: '8%'
                },
                {
                    name: 'Gingerbread',
                    calories: 356,
                    fat: 16.0,
                    carbs: 49,
                    protein: 3.9,
                    iron: '16%'
                },
                {
                    name: 'Jelly bean',
                    calories: 375,
                    fat: 0.0,
                    carbs: 94,
                    protein: 0.0,
                    iron: '0%'
                },
                {
                    name: 'Lollipop',
                    calories: 392,
                    fat: 0.2,
                    carbs: 98,
                    protein: 0,
                    iron: '2%'
                },
                {
                    name: 'Honeycomb',
                    calories: 408,
                    fat: 3.2,
                    carbs: 87,
                    protein: 6.5,
                    iron: '45%'
                },
                {
                    name: 'Donut',
                    calories: 452,
                    fat: 25.0,
                    carbs: 51,
                    protein: 4.9,
                    iron: '22%'
                },
                {
                    name: 'KitKat',
                    calories: 518,
                    fat: 26.0,
                    carbs: 65,
                    protein: 7,
                    iron: '6%'
                }
            ]
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
