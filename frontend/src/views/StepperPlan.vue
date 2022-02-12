<template>
  <v-stepper v-model="e1">
    <v-stepper-header>
      <v-stepper-step
        :complete="e1 > 1"
        step="1"
      >
        Race length
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
        <v-container
            color="transparent"
            height="200px"
        >
            <v-radio-group class="ma-12" v-model="radioRaceLength">
                <v-radio
                    class="mb-4"
                    :key="n"
                    label="5K (9 weeks of training)"
                    :value=1
                ></v-radio>
                <v-radio
                    class="mb-4"
                    :key="n"
                    label="10K (12 weeks of training)"
                    :value=2
                ></v-radio>
                <v-radio
                    class="mb-4"
                    :key="n"
                    label="HALF MARATHON (15 weeks of training)"
                    :value=3
                ></v-radio>
                <v-radio
                    class="mb-4"
                    :key="n"
                    label="MARATHON (18 weeks of training)"
                    :value=4
                ></v-radio>
            </v-radio-group>
        </v-container>

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
        <v-radio-group class="ma-12" v-model="radioRaceLevel">
                <v-radio
                    class="mb-4"
                    :key="1"
                    label="Level 1"
                    :value=1
                ></v-radio>
                <v-radio
                    class="mb-4"
                    :key="2"
                    label="Level 2"
                    :value=2
                ></v-radio>
                <v-radio
                    class="mb-4"
                    :key="3"
                    label="Level 3"
                    :value=3
                ></v-radio>
            </v-radio-group>

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
          height="200px"
        >
        </v-card>

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
</template>

<script>
export default {
    data () {
        return {
            e1: 1,
            radioRaceLength: 1,
            radioRaceLevel: 1
        };
    }
};
</script>
