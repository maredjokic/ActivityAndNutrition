<template>
  <v-app id="inspire">
    <v-content>
      <v-container
        fluid
      >
        <v-row
          align="center"
          justify="center"
        >
          <v-col
            cols="12"
            sm="8"
            md="4"
          >
            <v-card class="elevation-12">
              <v-toolbar
                color="primary"
                dark
                flat
              >
                <v-toolbar-title>Prijavi se</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-tooltip bottom>
                  <span>Source</span>
                </v-tooltip>
              </v-toolbar>
              <v-card-text>
                <v-form>
                <v-row>
                    <v-icon medium>mdi-account</v-icon>
                    <v-text-field
                        label="Login"
                        name="login"
                        type="text"
                    ></v-text-field>
                </v-row>
                <v-row>
                    <v-icon medium>mdi-lock</v-icon>
                    <v-text-field
                        id="password"
                        label="Password"
                        name="password"
                        type="password"
                    ></v-text-field>
                </v-row>
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="primary">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
    props: {
        source: String
    }
};
</script>
