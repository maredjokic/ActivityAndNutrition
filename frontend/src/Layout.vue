<template>
<div id="app">
<v-app>
  <v-app-bar absolute short app color="primary">
    <v-app-bar-nav-icon @click="drawer = !drawer" ></v-app-bar-nav-icon>
    <v-spacer></v-spacer>
    <v-spacer></v-spacer>
    <a><router-link v-bind:to="'/Prijava'" exact>
      <v-btn medium text class="ma-2" color="white">
        <v-icon>mdi-login</v-icon>
      </v-btn>
    </router-link></a>

    <a><router-link v-bind:to="'/Registracija'" exact>
      <v-btn medium text class="ma-2" color="white">
        <v-icon>mdi-account-plus</v-icon>
      </v-btn>
    </router-link></a>
  </v-app-bar>

    <v-navigation-drawer
      v-model="drawer"
      absolute
      temporary
    >
    <router-link class="routerLink" v-bind:to="'/createplan'" exact>
      <v-btn medium text class="ma-2" color="white">
        Create Plan
        <v-icon>mdi-run</v-icon>
        <v-icon>mdi-pen</v-icon>
      </v-btn>
    </router-link>
    <router-link class="routerLink" v-bind:to="'/myplan'" exact>
      <v-btn medium text class="ma-2" color="white">
        My Plan
        <v-icon>mdi-run</v-icon>
        <v-icon>mdi-notebook-outline</v-icon>
      </v-btn>
    </router-link>
    <v-spacer></v-spacer>
   <router-link class="routerLink" v-bind:to="'/Prijava'" exact>
      <v-btn medium text class="ma-2" color="white">
        Prijava
        <v-icon>mdi-login</v-icon>
      </v-btn>
    </router-link>
    <router-link class="routerLink" v-bind:to="'/Registracija'" exact>
      <v-btn medium text class="ma-2" color="white">
        Registracija
        <v-icon>mdi-account-plus</v-icon>
      </v-btn>
    </router-link>

    </v-navigation-drawer>

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
            activeBtn: [0, 1, 2],
            drawer: false
        };
    },
    components: {
    }
};
</script>

<style>
.routerLink{
    text-decoration: none;
}
</style>
