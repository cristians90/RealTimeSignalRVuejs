<template>
  <v-app>
  <v-toolbar app>
    <v-spacer></v-spacer>
    <v-toolbar-title>Realtime messages with SignalR ASP.NET Core / Vuejs </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-badge left>
      <span slot="badge">{{totalCount}}</span>
      <v-icon>notifications</v-icon>
    </v-badge>
  </v-toolbar>
  <v-content>
    <v-container align-center grid-list-md text-xs-center>
    <v-layout row wrap>
      <v-flex xs6>
        <v-card dark color="secondary">
          <v-card-title primary-title>
            <div class="headline">Common Messages: {{countMessages}}</div>
          </v-card-title>
        </v-card>
      </v-flex>
      <v-flex xs6>
        <v-card dark color="secondary">
          <v-card-title primary-title>
            <div class="headline">Info Messages: {{countInfo}}</div>
          </v-card-title>
        </v-card>
      </v-flex>
      <v-flex xs4>
        <v-card dark color="primary">
          <v-card-title primary-title>
            <div class="headline">Success Messages: {{countSuccess}}</div>
          </v-card-title>
        </v-card>
      </v-flex>
      <v-flex xs4>
        <v-card dark color="primary">
          <v-card-title primary-title>
            <div class="headline">Warning Messages: {{countWarning}}</div>
          </v-card-title>
        </v-card>
      </v-flex>
      <v-flex xs4>
        <v-card dark color="primary">
          <v-card-title primary-title>
            <div class="headline">Common Error: {{countError}}</div>
          </v-card-title>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
  </v-content>
</v-app>
</template>

<script>
import { mapGetters } from "vuex";

export default {
  name: "Home",
  computed: {
    ...mapGetters({
      countMessages: "countMessages",
      countInfo: "countInfo",
      countSuccess: "countSuccess",
      countWarning: "countWarning",
      countError: "countError"
    }),
    totalCount() {
      return (
        this.countMessages +
        this.countInfo +
        this.countSuccess +
        this.countWarning +
        this.countError
      );
    }
  }
};
</script>
