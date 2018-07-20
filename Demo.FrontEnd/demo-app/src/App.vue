<template>
  <div id="app" class="ui container">
    <div class="ui grid">
      <div class="row">
        <div class="column">
          <Header />
        </div>
      </div>
      <div class="row">
        <div class="column">
          <router-view/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Header from './components/Header';

export default {
  name: 'App',
  components: {
    Header,
  },
};
</script>

<style>
#app {
  margin:20px;
}
</style>
