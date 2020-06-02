<template>
<div id="app">
<v-app>
  <v-app-bar short app color="primary">
    <a><router-link v-bind:to="'/'" exact>
      <v-btn large text class="ma-2" color="white">
        Pocetna
        <v-icon>mdi-home</v-icon>
      </v-btn>
    </router-link></a>
    <a><router-link v-bind:to="'/Pregled'" exact>
      <v-btn large text class="ma-2" color="white">
        Pregled
        <v-icon>mdi-ballot-outline</v-icon>
      </v-btn>
    </router-link></a>
    <a><router-link v-bind:to="'/Trcanje'" exact>
      <v-btn large text class="ma-2" color="white">
        Trcanje
        <v-icon>mdi-run</v-icon>
      </v-btn>
    </router-link></a>
    <a><router-link v-bind:to="'/PlanTrcanja'" exact>
      <v-btn large text class="ma-2" color="white">
        Plan Trcanja
        <v-icon>mdi-notebook</v-icon>
      </v-btn>
    </router-link></a>
    <v-spacer></v-spacer>
    <a><router-link v-bind:to="'/Prijava'" exact>
      <v-btn large text class="ma-2" color="white">
        Prijava
        <v-icon>mdi-login</v-icon>
      </v-btn>
    </router-link></a>
    <a><router-link v-bind:to="'/Registracija'" exact>
      <v-btn large text class="ma-2" color="white">
        Registracija
        <v-icon>mdi-account-plus</v-icon>
      </v-btn>
    </router-link></a>
  </v-app-bar>

  <!-- Sizes your content based upon application components -->
  <v-content>

    <!-- Provides the application the proper gutter -->
    <v-container fluid>

      <!-- If using vue-router -->
      <router-view></router-view>
    </v-container>
  </v-content>

  <!-- <v-footer app>
  </v-footer> -->
</v-app>

</div>
</template>

<script>

export default {
    name: 'Layot',
    data () {
        return {
            activeBtn: [0, 1, 2]
        };
    },
    components: {
    }
};
</script>

<style>
</style>
