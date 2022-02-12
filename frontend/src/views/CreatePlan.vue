<template>
  <div>
    <v-card class="d-flex flex-column justify-space-between pa-4" style="height: 85vh;" flat>
        <v-card color="transparent" style="font-size: 20px;" flat>Choose a way to create a running plan</v-card>
        <v-btn color="#e66c2c" style="height: 25%; width: 100%; white-space: normal;">
          <span style="white-space: normal;">Use a personal trainer for a running plan
            </span>
          </v-btn>
          <v-btn color="secondary" style="height: 25%; width: 100%;"  @click="$router.push('StepperPlan')"><span style="white-space: normal; ">Plan for 5k, 10k, half marathon or marathon</span></v-btn>
        <v-btn color="secondary" style="height: 25%; width: 100%;"><span style="white-space: normal;">Create a new plan yourself</span></v-btn>
    </v-card>
  </div>
</template>

<script>

export default {
    name: 'CreatePlan',
    computed: {
    },
    data () {
        return {
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
