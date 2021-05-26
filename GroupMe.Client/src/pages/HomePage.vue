<template>
  <div>
    <div class="card m-4 shadow" v-for="g in groups" :key="g.id">
      <div class="card-body">
        <h3>
          {{ g.name }}
        </h3>
        <p>{{ g.description }}</p>
        <div>
          <button v-if="g.creator.id !== account.id" @click="joinGroup(g)">
            Join Group
          </button>
        </div>
      </div>
      <div class="card-footer text-right">
        <b>{{ g.creator.name }}</b>
        <img :src="g.creator.picture" alt="group creator image" class="rounded-circle elevation-1 mx-2" height="40">
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { groupsService } from '../services/GroupsService'

export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      groupsService.getGroups()
    })

    return reactive({
      account: computed(() => AppState.account),
      groups: computed(() => AppState.groups),
      joinGroup(g) {
        groupsService.joinGroup(g)
      }
    })
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
