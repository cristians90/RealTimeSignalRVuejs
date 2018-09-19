<template>
  <div id="app">
    <Home/>
  </div>
</template>

<script>
/*eslint no-console:*/
import Home from "./components/Home.vue";
import * as signalR from "@aspnet/signalr";
import { mapActions } from "vuex";

export default {
  name: "app",
  components: {
    Home
  },
  data() {
    return {
      notificationSystem: {
        options: {
          show: {
            theme: "dark",
            icon: "icon-person",
            position: "topCenter",
            progressBarColor: "rgb(0, 255, 184)",
            buttons: [
              [
                "<button>Ok</button>",
                // eslint-disable-next-line
                function(instance, toast) {
                  alert("Hello world!");
                },
                true
              ],
              [
                "<button>Close</button>",
                function(instance, toast) {
                  instance.hide(
                    {
                      transitionOut: "fadeOutUp",
                      onClosing: function(instance, toast, closedBy) {
                        console.info("closedBy: " + closedBy);
                      }
                    },
                    toast,
                    "buttonName"
                  );
                }
              ]
            ],
            // eslint-disable-next-line
            onOpening: function(instance, toast) {
              console.info("callback abriu!");
            },
            onClosing: function(instance, toast, closedBy) {
              console.info("closedBy: " + closedBy);
            }
          },
          ballon: {
            balloon: true,
            position: "bottomCenter"
          },
          info: {
            position: "bottomLeft"
          },
          success: {
            position: "bottomRight"
          },
          warning: {
            position: "topLeft"
          },
          error: {
            position: "topRight"
          },
          question: {
            timeout: 20000,
            close: false,
            overlay: true,
            toastOnce: true,
            id: "question",
            zindex: 999,
            position: "center",
            buttons: [
              [
                "<button><b>YES</b></button>",
                function(instance, toast) {
                  instance.hide({ transitionOut: "fadeOut" }, toast, "button");
                },
                true
              ],
              [
                "<button>NO</button>",
                function(instance, toast) {
                  instance.hide({ transitionOut: "fadeOut" }, toast, "button");
                }
              ]
            ],
            onClosing: function(instance, toast, closedBy) {
              console.info("Closing | closedBy: " + closedBy);
            },
            onClosed: function(instance, toast, closedBy) {
              console.info("Closed | closedBy: " + closedBy);
            }
          }
        }
      }
    };
  },
  methods: {
    ...mapActions({
      incrementMessages: "incrementMessages",
      incrementInfo: "incrementInfo",
      incrementSuccess: "incrementSuccess",
      incrementWarning: "incrementWarning",
      incrementError: "incrementError"
    })
  },
  mounted() {
    const connection = new signalR.HubConnectionBuilder()
      //.withUrl("https://localhost:5001/MessageHub")
      .withUrl("/MessageHub")
      .configureLogging(signalR.LogLevel.Information)
      .build();
    connection.start().catch(err => console.error(err.toString()));

    connection.on("MessageFromServer", message => {
      this.$toast.info(
        message,
        "Mensaje del server",
        this.notificationSystem.options.info
      );
      this.incrementMessages();
    });

    connection.on("InfoMessageFromServer", message => {
      this.$toast.info(
        message,
        "Información",
        this.notificationSystem.options.info
      );
      this.incrementInfo();
    });

    connection.on("SuccessMessageFromServer", message => {
      this.$toast.success(
        message,
        "Exito",
        this.notificationSystem.options.info
      );
      this.incrementSuccess();
    });

    connection.on("WarningMessageFromServer", message => {
      this.$toast.warning(
        message,
        "Atencion!",
        this.notificationSystem.options.info
      );
      this.incrementWarning();
    });

    connection.on("ErrorMessageFromServer", message => {
      this.$toast.error(
        message,
        "Error!",
        this.notificationSystem.options.info
      );
      this.incrementError();
    });
  }
};
</script>
