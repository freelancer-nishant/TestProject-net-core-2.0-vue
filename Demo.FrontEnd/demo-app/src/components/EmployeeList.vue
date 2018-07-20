<template>
  <div>
    <h1 class="ui header">Employee List</h1>
    <div class="ui grid">
      <div class="row">
        <div class="column">
          <div class="ui right floated small primary labeled icon button" @click="openModal">
            <i class="user icon"></i> Add Employee
          </div>
        </div>
      </div>
      <div class="row">
        <div class="column segment">
          <div v-bind:class="[isLoading ? 'ui dimmer active' : 'ui dimmer']">
            <div class="ui loader"></div>
          </div>
          <table class="ui compact celled table">
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>
                <th>Sex</th>
                <th>Email</th>
                <th>Phone No</th>
                <th>Department</th>
                <th>Employment Type</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="employee in employees">
                <td>{{employee.id}}</td>
                <td>{{employee.name}}</td>
                <td>{{employee.sex}}</td>
                <td>{{employee.email}}</td>
                <td>{{employee.phoneNo}}</td>
                <td>{{employee.departmentName}}</td>
                <td>{{employee.employmentType}}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
    <div>
      <employee-detail @update="onAddEmployee"></employee-detail>
    </div>
  </div>
</template>

<script>

  import axios from 'axios';
  import EmployeeDetail from '../components/EmployeeDetail'
  
  
  export default {
    name: 'EmployeeList',
    components: {
      EmployeeDetail
    },
    data() {
      return {
        employees: [],
        isLoading: false,
      }
    },
    created() {
      this.fetchData()
    },
    methods:{
      fetchData(){
        this.isLoading = true;
        axios.get(process.env.ROOT_API + '/employees')
          .then((resp) => {
          this.employees = resp.data.data;
          this.isLoading = false;
        })
        .catch((err) => {
          console.log(err)
          this.isLoading = false;
        })
      },
      openModal(){
         $('.ui.modal').modal('show');
      },
      onAddEmployee(){
        $('.ui.modal').modal('hide');
        this.fetchData();
      }
    }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">

</style>
