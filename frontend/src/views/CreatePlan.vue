<template>
  <div>
    <v-card class="d-flex flex-column justify-space-between pa-5" style="height: 85vh;" flat>
        <v-card color="transparent"  flat>Choose a way to create a running plan</v-card>
        <v-btn color="secondary" style="height: 20%; width: 100%;">Create a new plan yourself</v-btn>
        <v-btn color="secondary" style="height: 20%; width: 100%;">Plan to stay fit, lose weight and stay healthy</v-btn>
        <v-btn color="secondary" style="height: 20%; width: 100%;"><div style="width: 100%;">Plan for 5k, 10k, half marathon, marathon, etc</div></v-btn>
        <v-btn color="#e66c2c" style="height: 20%; width: 100%;">Use a personal trainer for a running plan</v-btn>
    </v-card>
    <v-stepper v-if="false" v-model="e1">
    <v-stepper-header>
      <v-stepper-step
        :complete="e1 > 1"
        step="1"
      >
        Name of step 1
      </v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step
        :complete="e1 > 2"
        step="2"
      >
        Name of step 2
      </v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step step="3">
        Name of step 3
      </v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>
      <v-stepper-content step="1">
        <v-card
          class="mb-12"
          color="grey lighten-1"
          height="200px"
        ></v-card>

        <v-btn
          color="primary"
          @click="e1 = 2"
        >
          Continue
        </v-btn>

        <v-btn text>
          Cancel
        </v-btn>
      </v-stepper-content>

      <v-stepper-content step="2">
        <v-card
          class="mb-12"
          color="grey lighten-1"
          height="200px"
        ></v-card>

        <v-btn
          color="primary"
          @click="e1 = 3"
        >
          Continue
        </v-btn>

        <v-btn text>
          Cancel
        </v-btn>
      </v-stepper-content>

      <v-stepper-content step="3">
        <v-card
          class="mb-12"
          color="grey lighten-1"
          height="200px"
        ></v-card>

        <v-btn
          color="primary"
          @click="e1 = 1"
        >
          Continue
        </v-btn>

        <v-btn text>
          Cancel
        </v-btn>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
  </div>
</template>

<script>

export default {
    name: 'CreatePlan',
    computed: {
    },
    data () {
        return {
            e1: 1
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
