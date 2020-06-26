<template>
  <v-card>
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
            <v-card-text>{{ item.content }}</v-card-text>
          </v-card>
        </v-tab-item>
      </v-tabs-items>
  </v-card>
</template>

<script>

export default {
    name: 'PlanTrcanja',
    computed: {
    },
    data () {
        return {
            tab: null,
            items: [
                { tab: 'Pregled', content: 'Tab 1 Content' },
                { tab: 'Proračun', content: 'Tab 2 Content' },
                { tab: 'Plan', content: 'Tab 3 Content' },
                { tab: 'Saveti', content: 'Tab 4 Content' }
            ]
        };
    },
    components: {
    },
    mounted: function () {
    },
    methods: {
    }
};
</script>

<style>
</style>
