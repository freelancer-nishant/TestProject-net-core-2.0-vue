import Vue from 'vue'
import Router from 'vue-router'
import EmployeeList from '@/components/EmployeeList'
import Report from '@/components/Report'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'EmployeeList',
      component: EmployeeList
    },
    {
        path: '/report',
        name: 'Report',
        component: Report
    },
  ]
})
