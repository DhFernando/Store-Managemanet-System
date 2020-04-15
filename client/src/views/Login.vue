<template>
    <div class="mt-5">
        <v-container class="fill-height " fluid >
        <v-row align="center" justify="center" >
          <v-col cols="12" sm="8" md="4" >
            <v-card class="elevation-12">
              <v-toolbar color="primary" dark flat>
                <v-toolbar-title>Login</v-toolbar-title>
                <v-spacer />
                <v-tooltip bottom>
                  
                </v-tooltip>
                <v-tooltip right>
                  
                </v-tooltip>
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field  label="Login" name="login"  type="text" /> 
                  <v-text-field id="password" label="Password" name="password"  type="password" />
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </div>
</template>

<script>
export default {
    name:'Login'
}
</script>

<style>

</style>