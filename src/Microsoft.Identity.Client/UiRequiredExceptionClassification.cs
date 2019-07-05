// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Identity.Client
{
    /// <summary>
    /// Details about the cause of an <see cref="MsalUiRequiredException"/>, giving a hint about what the user can expect when 
    /// they go through interactive authentication. See https://aka.ms/msal-net-UiRequiredException for details.
    /// </summary>
    public enum UiRequiredExceptionClassification
    {
        /// <summary>
        /// No further details are provided. It is possible that the user will be able to resolve the issue by launching interactive authentication.
        /// See https://aka.ms/msal-net-UiRequiredExceptionfor details
        /// </summary>
        None,

        /// <summary>
        /// Condition cannot be resolved at this time. Launching interactive authentication flow will show a message explaining the condition.
        /// See https://aka.ms/msal-net-UiRequiredExceptionfor details
        /// </summary>
        MessageOnly,

        /// <summary>
        /// Condition can be resolved by user interaction during the interactive authentication flow.
        /// See https://aka.ms/msal-net-UiRequiredExceptionfor details
        /// </summary>
        BasicAction,

        /// <summary>
        /// Condition can be resolved by additional remedial interaction with the system, outside of the interactive authentication flow.
        /// See https://aka.ms/msal-net-UiRequiredExceptionfor details
        /// </summary>
        AdditionalAction,

        /// <summary>
        /// User consent is missing, or has been revoked.
        /// See https://aka.ms/msal-net-UiRequiredException for details
        /// </summary>
        ConsentRequired,

        /// <summary>
        /// User's password has expired. 
        /// See https://aka.ms/msal-net-UiRequiredExceptionfor details.
        /// </summary>
        UserPasswordExpired
    }
}
