using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using G_POS.POS.Helpers;

namespace GrandDBHelperNS
{
    class Grand_DB_Manager
    {

        /*
         *  -- SET CONNECTION STRING  //192x.168.1.150-mwenge   192x.168.1.4-mikochec  192x.168.0.20-mbezi 192.168.1.100-teg
         */
        public string connection_string = "";//@"Server='localhost';Port=3306;Database='poa_supermarket';Uid='grand';Password='password';Persist Security Info=True;Convert Zero Datetime=True;";
        
        /*
         *  -- DB CONNECTION DETAILS
         */
        public MySqlConnection CONNECTION;
        public MySqlCommand COMMAND;
        public MySqlDataReader DATA_READER;
        public Grand_Custom_Result resultStatus;
        public List<Grand_Base_Model> RESULT_OBJECT;
        public Grand_Model_Registration MODEL_REGISTRATION = new Grand_Model_Registration();
        private CustomLocalDBHelper MDBLocalHelper;//
        private G_POS.POS.Models.LocalDBConstantModel DB_CONSTANTS;//


        //constructor
        public Grand_DB_Manager()
        {
            MDBLocalHelper = new CustomLocalDBHelper();//
            DB_CONSTANTS = MDBLocalHelper.getDBSetting();//
            this.connection_string = @"Server='" + DB_CONSTANTS.server_ip + "';Port=" + DB_CONSTANTS.port + ";Database='" + DB_CONSTANTS.database + "';Uid='" + DB_CONSTANTS.user + "';Password='" + DB_CONSTANTS.password + "';Persist Security Info=True;Convert Zero Datetime=True;";

            CONNECTION = new MySqlConnection();
            CONNECTION.ConnectionString = this.connection_string;
           
            //System.Windows.Forms.MessageBox.Show(DB_CONSTANTS.database);
        }


        //connect to the db
        public Grand_Custom_Result getListFromQuery(string query,string SpecificModel)
        {
            
            

            //try open the connection
            try
            {
                CONNECTION.Open();
                
                COMMAND = new MySqlCommand(query,CONNECTION);
                DATA_READER = COMMAND.ExecuteReader();


                //now generate a list
                List<Grand_Base_Model> myList = new List<Grand_Base_Model>();
                
                
                while (DATA_READER.Read())
                {
                    var model = MODEL_REGISTRATION.getModelInstance(SpecificModel);
                    string[] __array = model.my_db_fields();

                    //model
                    //dynamic dynamicModel = new System.Dynamic.ExpandoObject();
                    int aray_size = model.my_db_fields().Length;

                    //moving over col fields
                    for (int i = 0; i < aray_size; i ++ )
                    {
                       // var _arr_of_i = __array[i] == null ? 
                        model.set_unique_field(__array[i], DATA_READER.GetString(__array[i]));
                    }
                    myList.Add(model);
                }

                RESULT_OBJECT = myList;

                //on success return results
                resultStatus = new Grand_Custom_Result(0, "DB_SUCCESS", "DB_SUCCESS", myList);
                return resultStatus;

            }
            catch (Exception exp)
            {
                
                //System.Windows.Forms.MessageBox.Show("hey");
                RESULT_OBJECT = new List<Grand_Base_Model>();
                //generate an error msg
                resultStatus = new Grand_Custom_Result(1, "DB_ERROR", exp.Message.ToString(), RESULT_OBJECT);
                return resultStatus;
            }
            finally {  CONNECTION.Close(); };
            
        }//end connect  2 DB




        //add new Object to the database
        public Grand_Custom_Result addThisObject(Object Obj, string SpecificObjName, string table_name)
        {
            /*
                QUERY GENERATION PROCESS
            */

            Grand_Base_Model model = MODEL_REGISTRATION.getModelInstance(SpecificObjName);
            model = (Grand_Base_Model)Obj;
            string[] __array = model.my_db_fields();
            int aray_size = model.my_db_fields().Length;

            //generate a unique query for every model
            StringBuilder custom_query = new StringBuilder();
            custom_query.Append("INSERT INTO " + table_name + "(");

            //moving over col fields
            StringBuilder values = new StringBuilder();
            for (int i = 0; i < aray_size; i++)
            {
                values.Append(__array[i]);
                values.Append(",");
            }
            //remove last char
            values.Length--;
            values.Append(") VALUES (");


            //actual values
            StringBuilder data_values = new StringBuilder();
            for (int i = 0; i < aray_size; i++)
            {
                data_values.Append(model.GetPropValue(model,__array[i]));
                data_values.Append(",");
            }
            data_values.Length--;
            data_values.Append(");");

            //append values and data_values
            custom_query.Append(values.ToString());
            custom_query.Append(data_values.ToString());

            /*
                END QUERY GENERATION PROCESS
            */



            try {
                CONNECTION.Open();
                COMMAND = new MySqlCommand(custom_query.ToString(),CONNECTION);
                COMMAND.ExecuteNonQuery();
                //on success return results
                resultStatus = new Grand_Custom_Result(0, "DB_SUCCESS", "DB_SUCCESS", RESULT_OBJECT);
                return resultStatus;
            }
            catch (Exception exp) {
                resultStatus = new Grand_Custom_Result(1, "DB_ERROR", exp.Message, RESULT_OBJECT);
                return resultStatus;
            }
            finally { CONNECTION.Close(); };
        }//end add new Object to the database





        //basic query
        public Grand_Custom_Result RunBasicQuery(string query)
        {
            try
            {
                CONNECTION.Open();
                COMMAND = new MySqlCommand(query.ToString(), CONNECTION);
                COMMAND.ExecuteNonQuery();
                //on success return results
                resultStatus = new Grand_Custom_Result(0, "DB_SUCCESS", "DB_SUCCESS", RESULT_OBJECT);
                return resultStatus;
            }
            catch (Exception exp)
            {
                resultStatus = new Grand_Custom_Result(1, "DB_ERROR", exp.Message, RESULT_OBJECT);
                return resultStatus;
            }
            finally { CONNECTION.Close(); };
        }
        //end basic query


    }
}
