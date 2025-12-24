// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Ecommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission","DiscountReadPermission"}},
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission","OrderReadPermission"}},
           new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission","CargoReadPermission"}},
           new ApiResource("ResourceReview"){Scopes={ "ReviewFullPermission"}},
           new ApiResource("ResourceCart"){Scopes={"CartFullPermission"}},
           new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
           new ApiResource("ResourceImage"){Scopes={"ImageFullPermission"}},
           new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
           new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
           new ApiResource("ResourceUser"){Scopes={"UserFullPermission"}},
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            {
                Scopes = { IdentityServerConstants.LocalApi.ScopeName }
           },
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("DiscountReadPermission","Reading authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("CartFullPermission","Full authority for cart operations"),
            new ApiScope("ReviewFullPermission","Full authority for review operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImageFullPermission","Full authority for image operations"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope("UserFullPermission","Full authority for user operations"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName, "Access to IdentityServer API") 

        }; 

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="EcommerceVisitorId",
                ClientName="Ecommerce Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowOfflineAccess = true, 

                AllowedScopes = { "MessageFullPermission", "OrderFullPermission", "DiscountFullPermission", "CartFullPermission", "CatalogFullPermission", "OcelotFullPermission", "ReviewFullPermission", "ImageFullPermission"}
            },

            //Manager
            new Client
            {
                ClientId="EcommerceManagerId",
                ClientName="Ecommerce Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowOfflineAccess = true,

                AllowedScopes={"UserFullPermission","CargoFullPermission" ,"MessageFullPermission","OrderFullPermission", "DiscountFullPermission","CatalogFullPermission", "CartFullPermission",
                    "OcelotFullPermission","ReviewFullPermission","PaymentFullPermission","ImageFullPermission","ReviewFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OfflineAccess,
               },
                                AccessTokenLifetime=600

            },

            //Admin
            new Client
            {
                ClientId="EcommerceAdminId",
                ClientName="Ecommerce Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowOfflineAccess = true,
                AllowedScopes={"UserFullPermission","CargoFullPermission" , "MessageFullPermission","OrderFullPermission" ,"CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","OcelotFullPermission",
                    "CartFullPermission","ReviewFullPermission","PaymentFullPermission","ImageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }
        };
    }
}