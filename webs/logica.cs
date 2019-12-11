using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using webservices;
namespace webs
{
    public class logica
    {
        //private object dbwebs;

        public void altadirecciones(string cod, string dir, string des, string fec)
        {
            websEntities dbwebs = new websEntities() ;            
            direccionesweb dirweb = new direccionesweb();
            dirweb.diw_cod = cod;
            dirweb.diw_dir = dir;
            dirweb.diw_des = des;
            dirweb.diw_fec = Convert.ToDateTime(fec);
            dbwebs.direccioneswebs.Add(dirweb);
            dbwebs.SaveChanges();
            MessageBox.Show("La web ingresó correctamente.");        
        }
        public string[] consultadirecciones(string cod, string dir, string des, string fed, string feh, string boton)
        {
            int suc = cod.Length;
            string[] web = {};
            //tring texto = "";
            using (websEntities dbwebs = new websEntities())
            {

                /*
                var direcciones = from dir2 in dbwebs.direccioneswebs
                                  where dir2.diw_cod.Equals(cod)
                                  select dir2;
                */
                if (boton == "button1")
                {
                    direccionesweb dirweb = dbwebs.direccioneswebs
                                         .Where(di => di.diw_cod.Substring(0, suc) == cod)
                                         .OrderBy(di => di.diw_cod)
                                         .First();
                    web[0] = dirweb.diw_dir;
                    web[1] = dirweb.diw_des;
                    //web[2] = dirweb.diw_fec;
                }
                if(boton == "btncdavanzar")
                {
                    direccionesweb dirweb = dbwebs.direccioneswebs
                                         .Where(di => di.diw_cod.Substring(0, suc) == cod)
                                         .OrderBy(di => di.diw_cod)
                                         .First();
                    web[0] = dirweb.diw_dir;
                    web[1] = dirweb.diw_des;
                   // web[2] = dirweb.diw_fec;
                }
                return web;
            }
        }

        }
    }

