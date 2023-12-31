﻿namespace SellPhones.Commons
{
    public static class RoleName
    {
        public enum RoleBlock
        {
            Admin = 0,
            Blog = 1,
            Course = 2,
            FAQ = 3,
            Learner = 4,
            Subscription = 5,
            User = 6,
            Vocabulary = 7,
            Customer = 8,
            AccountRequest = 9,
            StaticPage = 10,
            FeedBack = 11,
            UsageStatistics = 12,
            LeanrnQuality = 13,
            DemoGraphic = 14,
            Access = 15,
            UnitVocabulary = 16
        }

        public const string ROLE_SYSTEM_ADMINISTRATORS = "SuperAdmin";
        public const string ROLE_SYSTEM_MANAGER = "Manager";

        public static class RoleNameEN
        {
            //Important : admin
            public const string Permission_roles_admin = "Permission_roles_admin";

            #region Blog

            public const string Permission_roles_blog_can_view = "Permission_roles_blog_can_view";
            public const string Permission_roles_blog_can_create = "Permission_roles_blog_can_create";
            public const string Permission_roles_blog_can_edit = "Permission_roles_blog_can_edit";
            public const string Permission_roles_blog_can_delete = "Permission_roles_blog_can_delete";

            #endregion Blog

            #region Course

            public const string Permission_roles_course_can_view = "Permission_roles_course_can_view";
            public const string Permission_roles_course_can_create = "Permission_roles_course_can_create";
            public const string Permission_roles_course_can_edit = "Permission_roles_course_can_edit";
            public const string Permission_roles_course_can_delete = "Permission_roles_course_can_delete";
            public const string Permission_roles_course_can_export = "Permission_roles_course_can_export";
            public const string Permission_roles_course_can_import = "Permission_roles_course_can_import";

            #endregion Course

            #region FAQ

            public const string Permission_roles_faq_can_view = "Permission_roles_faq_can_view";
            public const string Permission_roles_faq_can_create = "Permission_roles_faq_can_create";
            public const string Permission_roles_faq_can_edit = "Permission_roles_faq_can_edit";
            public const string Permission_roles_faq_can_delete = "Permission_roles_faq_can_delete";

            #endregion FAQ

            #region Learner

            public const string Permission_roles_learner_can_view = "Permission_roles_learner_can_view";
            public const string Permission_roles_learner_can_create = "Permission_roles_learner_can_create";
            public const string Permission_roles_learner_can_edit = "Permission_roles_learner_can_edit";
            public const string Permission_roles_learner_can_delete = "Permission_roles_learner_can_delete";

            #endregion Learner

            #region Subscription

            public const string Permission_roles_subscription_can_view = "Permission_roles_subscription_can_view";
            public const string Permission_roles_subscription_can_create = "Permission_roles_subscription_can_create";
            public const string Permission_roles_subscription_can_edit = "Permission_roles_subscription_can_edit";
            public const string Permission_roles_subscription_can_delete = "Permission_roles_subscription_can_delete";

            #endregion Subscription

            #region User

            public const string Permission_roles_user_can_view = "Permission_roles_user_can_view";
            public const string Permission_roles_user_can_create = "Permission_roles_user_can_create";
            public const string Permission_roles_user_can_edit = "Permission_roles_user_can_edit";
            public const string Permission_roles_user_can_delete = "Permission_roles_user_can_delete";

            #endregion User

            #region Vocabulary

            public const string Permission_roles_vocabulary_can_view = "Permission_roles_vocabulary_can_view";
            public const string Permission_roles_vocabulary_can_create = "Permission_roles_vocabulary_can_create";
            public const string Permission_roles_vocabulary_can_edit = "Permission_roles_vocabulary_can_edit";
            public const string Permission_roles_vocabulary_can_delete = "Permission_roles_vocabulary_can_delete";
            public const string Permission_roles_vocabulary_can_export = "Permission_roles_vocabulary_can_export";
            public const string Permission_roles_vocabulary_can_import = "Permission_roles_vocabulary_can_import";

            #endregion Vocabulary

            #region Customer

            public const string Permission_roles_customer_can_view = "Permission_roles_customer_can_view";
            public const string Permission_roles_customer_can_create = "Permission_roles_customer_can_create";
            public const string Permission_roles_customer_can_edit = "Permission_roles_customer_can_edit";
            public const string Permission_roles_customer_can_delete = "Permission_roles_customer_can_delete";
            public const string Permission_roles_customer_can_export = "Permission_roles_customer_can_export";
            public const string Permission_roles_customer_can_import = "Permission_roles_customer_can_import";
            public const string Permission_roles_customer_can_sendemail = "Permission_roles_customer_can_sendemail";

            #endregion Customer

            #region Static page

            public const string Permission_roles_static_page_can_view = "Permission_roles_static_page_can_view";
            public const string Permission_roles_static_page_can_create = "Permission_roles_static_page_can_create";
            public const string Permission_roles_static_page_can_update = "Permission_roles_static_page_can_update";
            public const string Permission_roles_static_page_can_delete = "Permission_roles_static_page_can_delete";

            #endregion Static page

            #region AccountRquest

            public const string Permission_roles_account_request_can_view = "Permission_roles_account_request_can_view";
            public const string Permission_roles_account_request_can_create = "Permission_roles_account_request_can_create";
            public const string Permission_roles_account_request_can_edit = "Permission_roles_account_request_can_edit";
            public const string Permission_roles_account_request_can_delete = "Permission_roles_account_request_can_delete";
            public const string Permission_roles_account_request_can_export = "Permission_roles_account_request_can_export";

            #endregion AccountRquest

            #region FeedBack

            public const string Permission_roles_feedBack_can_view = "Permission_roles_feedBack_can_view";
            public const string Permission_roles_feedBack_can_create = "Permission_roles_feedBack_can_create";
            public const string Permission_roles_feedBack_can_update = "Permission_roles_feedBack_can_update";
            public const string Permission_roles_feedBack_can_delete = "Permission_roles_feedBack_can_delete";

            #endregion FeedBack

            #region DSH

            public const string Permission_roles_DSH_can_view = "Permission_roles_DSH_can_view";
            public const string Permission_roles_DSH_can_export = "Permission_roles_DSH_can_export";
            //public const string Permission_roles_DSH_can_create = "Permission_roles_DSH_can_create";
            //public const string Permission_roles_DSH_can_update = "Permission_roles_DSH_can_update";
            //public const string Permission_roles_DSH_can_delete = "Permission_roles_DSH_can_delete";

            #endregion DSH

            #region CLHT

            public const string Permission_roles_CLHT_can_view = "Permission_roles_CLHT_can_view";
            public const string Permission_roles_CLHT_can_export = "Permission_roles_CLHT_can_export";

            #endregion CLHT

            #region SDAPP

            public const string Permission_roles_SDAPP_can_view = "Permission_roles_SDAPP_can_view";
            public const string Permission_roles_SDAPP_can_export = "Permission_roles_SDAPP_can_export";

            #endregion SDAPP

            #region Từ vựng của unit

            public const string Permission_roles_unit_vocabulary_can_create = "Permission_roles_unit_vocabulary_can_create";
            public const string Permission_roles_unit_vocabulary_can_import = "Permission_roles_unit_vocabulary_can_import";
            public const string Permission_roles_unit_vocabulary_can_delete = "Permission_roles_unit_vocabulary_can_delete";

            #endregion Từ vựng của unit

            #region Quyen truy cap

            public const string Permission_roles_access_can_view = "Permission_roles_access_can_view";
            public const string Permission_roles_access_can_create = "Permission_roles_access_can_create";
            public const string Permission_roles_access_can_update = "Permission_roles_access_can_update";
            public const string Permission_roles_access_can_delete = "Permission_roles_access_can_delete";

            #endregion Quyen truy cap
        }
    }
}