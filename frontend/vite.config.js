import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: {
      "@": "/src", // Para facilitar importações
    },
  },
  server: {
    port: 5173,
  },
});
