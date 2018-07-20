<template>
  <div  class="ui modal">
    <div class="header">Add Employee</div>
    <div class="content">
      <form class="ui form" @submit="submitForm">
        <div class="field">
          <label>Name</label>
          <input name="name" v-model="employee.name" placeholder="Name" type="text" />
        </div>
        <div class="fields">
          <div class="two wide field">
            <label>Gender</label>
            <select class="ui search dropdown" v-model="employee.sex" name="sex">
              <option value="M">Male</option>
              <option value="F">Female</option>
            </select>
          </div>
          <div class="seven wide field">
            <label>Email</label>
            <input name="email" placeholder="Email" v-model="employee.email" type="text" />
          </div>
          <div class="seven wide field">
            <label>Phone</label>
            <input name="phone" placeholder="Phone" v-model="employee.phoneNo" type="text" />
          </div>
        </div>
        <div class="fields">
          <div class="eight wide field">
            <label>Employment Type</label>
            <select class="ui selection dropdown" name="employmenttype" v-model="employee.employmentTypeId">
              <option value=""></option>
              <option v-for="e in employmentTypes" :value="e.id">{{e.type}}</option>
            </select>
          </div>
          <div class="eight wide field">
            <label>Department</label>
            <select class="ui selection dropdown" name="department" v-model="employee.departmentId">
              <option value=""></option>
              <option v-for="d in departments" :value="d.id">{{d.name}}</option>
            </select>
          </div>
        </div>
        <div class="field">
          <label>Address</label>
          <input name="address" placeholder="Address" type="text" v-model="employee.address" />
        </div>
        <button v-bind:class="[isLoading ? 'ui primary loading button' : 'ui primary button']" type="submit">Submit</button>
      </form>
    </div>
  </div>
</template>

<script>

  import axios from 'axios';
  
  
  export default {
    name: 'EmployeeDetail',
    data() {
      return {
        employee: {
          name: null,
          sex: null,
          email: null,
          phoneNo: null,
          address: null,
          employmentTypeId: null,
          departmentId: null
        },
        employmentTypes: [],
        departments:[],
        isLoading: false,
      }
    },
    created() {
      this.getDepartments();
      this.getEmploymentTypes();
    },
    mounted(){
      $('.ui.form')
      .form({
        fields: {
          name     : 'empty',
          sex   : 'empty',
          email : ['empty', 'email'],
          employmenttype : 'empty',
          department   : 'empty'
        }
      });
    },
    methods:{
      submitForm: function(e){
          if($('.ui.form').form('is valid') == false){
            return;
          }
          this.isLoading = true;
           axios.post(process.env.ROOT_API + '/employees', this.employee)
            .then((resp) => {
            this.employee.name = null;
            this.employee.sex = null;
            this.employee.email = null;
            this.employee.phoneNo = null;
            this.employee.address = null;
            this.employee.employmentTypeId = null;
            this.employee.departmentId = null;
            this.isLoading = false;
            this.$emit('update');
          })
          .catch((err) => {
            console.log(err)
            this.isLoading = false;
          })

          
          e.preventDefault();
      },
      getDepartments(){
       axios.get(process.env.ROOT_API + '/departments')
          .then((resp) => {
          this.departments = resp.data.data;
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
      }
    }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">

</style>
