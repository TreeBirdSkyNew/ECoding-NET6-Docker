using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class Director
    {
        private IBuilderEntityFramework _builderEntityFramework;
        private IBuilderAngular _builderAngular;
        private IBuilderWebApi _builderWebApi;
        private IBuilderWebMVC _builderWebMVC;
        private IBuilderApiGateWay _builderApiGateWay;

        public IBuilderWebApi BuilderWebApi
        {
            set { _builderWebApi = value; }
        }

        public void BuildWebApi()
        {
            this._builderWebApi.BuilderControllerWebApi("BuilderControllerWebApi");
            this._builderWebApi.BuilderApiRouting("BuilderApiRouting");
            this._builderWebApi.BuilderApiActionFilter("BuilderApiActionFilter");
            this._builderWebApi.BuilderApiResultFilter("BuilderApiResultFilter");
            this._builderWebApi.BuilderApiMiddleWare("BuilderApiMiddleWare");
            this._builderWebApi.BuilderApiConfiguration("BuilderApiConfiguration");
        }

        public IBuilderWebMVC BuilderWebMVC
        {
            set { _builderWebMVC = value; }
        }

        public void BuildWebMVC()
        {
            this._builderWebMVC.BuilderControllerMVC("BuilderControllerMVC");
            this._builderWebMVC.BuilderControllerRouting("BuilderControllerRouting");
            this._builderWebMVC.BuilderActionFilter("BuilderActionFilter");
            this._builderWebMVC.BuilderConfiguration("BuilderConfiguration");
            this._builderWebMVC.BuilderConfigure("BuilderConfigure");
            this._builderWebMVC.BuilderMiddleWare("BuilderMiddleWare");
            this._builderWebMVC.BuilderResultFilter("BuilderResultFilter");
        }

        public IBuilderApiGateWay BuilderApiGateWay
        {
            set { _builderApiGateWay = value; }
        }

        public void BuildApiGateWay()
        {
            this._builderApiGateWay.BuilderApiGateWayEnvoy("BuilderApiGateWayEnvoy");
            this._builderApiGateWay.BuilderApiGateWayMobileBff("BuilderApiGateWayMobileBff");
            this._builderApiGateWay.BuilderApiGateWayWebBff("BuilderApiGateWayWebBff");
        }

        public IBuilderAngular BuilderAngular
        {
            set { _builderAngular = value; }
        }

        public void BuildAngular()
        {
            this._builderAngular.BuilderAngularApp("BuilderAngularApp");
            this._builderAngular.BuilderAngularController("BuilderAngularController");
            this._builderAngular.BuilderAngularRounting("BuilderAngularRounting");
            this._builderAngular.BuilderAngularService("BuilderAngularService");
            this._builderAngular.BuilderAngularView("BuilderAngularView");
        }

        
        public IBuilderEntityFramework BuilderEntityFramework
        {
            set { _builderEntityFramework = value; }
        }

        public void BuildEntityFramework()
        {
            this._builderEntityFramework.BuildDAL("BuildDAL");
            this._builderEntityFramework.BuildEFDbContext("BuildEFDbContext");
            this._builderEntityFramework.BuildEFConfiguration("BuildEFConfiguration");
        }



        









    }
}
