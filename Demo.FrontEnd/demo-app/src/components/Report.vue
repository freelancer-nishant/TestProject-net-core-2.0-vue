<template>
  <div>
    <h1 class="ui header">Report</h1>
    <div class="ui segment">
      <form class="ui form">
        <div class="fields">
          <div class="four wide field">
            <label>Department</label>
            <select class="ui selection dropdown" name="department" v-model="departmentId">
              <option value=""></option>
              <option v-for="d in departments" :value="d.id">{{d.name}}</option>
            </select>
          </div>
          <div class="five wide field">
            <label>Employment Type</label>
            <select class="ui selection dropdown" name="employmenttype" v-model="employmentTypeId">
              <option value=""></option>
              <option v-for="e in employmentTypes" :value="e.id">{{e.type}}</option>
            </select>
          </div>
          <div class="five wide field">
            <label>Employee</label>
            <select class="ui selection dropdown" name="employmenttype" v-model="employeeId">
              <option value=""></option>
              <option v-for="e in employees" :value="e.id">{{e.name}}</option>
            </select>
          </div>
          <div class="one wide field">
            <label>&nbsp;</label>
            <button class="ui primary button" type="button"  @click="fetchReport">Submit</button>
          </div>
        </div>
      </form>
    </div>
    <div class="ui segment">
      <div class="ui grid">
        <div class="row">
          <div class="column">
            <div v-bind:class="[isLoading ? 'ui dimmer active' : 'ui dimmer']">
              <div class="ui loader"></div>
            </div>
            <div class="ui grid" v-for="data in reportData">
              <div class="one wide column">
              </div>
              <div class="fifteen wide column">
                {{data.day}}
                <div class="ui grid" v-for="task in data.tasks">
                  <div class="one wide column">
                  </div>
                  <div class="fifteen wide column">
                    {{task.task}}
                    <div class="ui grid" v-for="department in task.departments">
                      <div class="one wide column">
                      </div>
                      <div class="fifteen wide column">
                        {{department.department}}
                        <div class="ui grid" v-for="employmentType in department.employmentTypes">
                          <div class="one wide column">
                          </div>
                          <div class="fifteen wide column">
                            {{employmentType.employmentType}}
                            <div class="ui grid">
                              <div class="one wide column">
                              </div>
                              <div class="fifteen wide column">
                                <div v-for="employee in employmentType.employees">{{employee}}</div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import axios from 'axios';
  
  export default {
    name: 'Report',
    data() {
      return {
        departmentId: null,
        employmentTypeId: null,
        employeeId: null,
        employmentTypes: [],
        departments:[],
        employees:[],
        reportData:[],
        isLoading: false,
      }
    },
    created() {
      this.getDepartments();
      this.getEmploymentTypes();
      this.getEmployees();
    },
    methods:{
       getDepartments(){
       axios.get(process.env.ROOT_API + '/departments')
          .then((resp) => {
          this.departments = resp.data.data;
        })
        .catch((err) => {
          console.log(err)
        }) 
      },
      getEmployees(){
           axios.get(process.env.ROOT_API + '/employees')
          .then((resp) => {
          this.employees = resp.data.data;
        })
        .catch((err) => {
          console.log(err)
        }) 
      },
      getEmploymentTypes(){
        axios.get(process.env.ROOT_API + '/employmentTypes')
          .then((resp) => {
          this.employmentTypes = resp.data.data;
        })
        .catch((err) => {
          console.log(err)
        }) 
      },
      fetchReport(){
        this.isLoading = true;
        axios.get(process.env.ROOT_API + '/reports?'
                          + (this.departmentId != null ? 'departmentId=' + this.departmentId + '&' : '')
                          + (this.employmentTypeId != null ? 'employmentTypeId=' + this.employmentTypeId + '&': '')
                          + (this.employeeId != null ? 'employeeId=' + this.employeeId : ''))
          .then((resp) => {
            this.reportData = resp.data.data;
            this.isLoading = false;
        })
        .catch((err) => {
          console.log(err)
          this.isLoading = false;
        }) 
      },
    }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
  .ui.grid+.grid{
  margin-top: -1rem;
  }
</style>
