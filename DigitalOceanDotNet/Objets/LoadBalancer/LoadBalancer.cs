using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace DigitalOceanDotNet.Objets.LoadBalancer
{
    public class LoadBalancer
    {
        /// <summary>
        /// A unique ID that can be used to identify and reference a load balancer.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// A human-readable name for a load balancer instance.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// An attribute containing the public-facing IP address of the load balancer.
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; } = string.Empty;

        /// <summary>
        /// Each available load balancer size now equates to the load balancer having a set number of nodes
        /// </summary>
        [Obsolete("This field has been replaced by the size_unit field for all regions except in AMS2, NYC2, and SFO1")]
        [JsonProperty("size")]
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// How many nodes the load balancer contains. Each additional node increases the load balancer's ability to manage more connections
        /// </summary>
        [JsonProperty("size_unit")]
        public int SizeUnit { get; set; } = 0;

        [Obsolete("This field has been deprecated. You can no longer specify an algorithm for load balancers.")]
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = string.Empty;

        /// <summary>
        /// A status string indicating the current state of the load balancer. This can be new, active, or errored.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the load balancer was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// An array of objects specifying the forwarding rules for a load balancer
        /// </summary>
        [JsonProperty("forwarding_rules")]
        public List<ForwardingRule> ForwardingRules { get; set; } = new List<ForwardingRule>();

        /// <summary>
        /// An object specifying health check settings for the load balancer
        /// </summary>
        [JsonProperty("health_check")]
        public HealthCheck HealthCheck { get; set; } = new HealthCheck();

        /// <summary>
        /// An object specifying sticky sessions settings for the load balancer
        /// </summary>
        [JsonProperty("sticky_sessions")]
        public StickySessions StickySessions { get; set; } = new StickySessions();

        [JsonProperty("region")]
        public Region.Region Region { get; set; } = new Region.Region();

        [JsonProperty("tag")]
        public string Tag { get; set; } = string.Empty;

        [JsonProperty("droplet_ids")]
        public List<int> DropletIds { get; set; } = new List<int>();

        /// <summary>
        /// A boolean value indicating whether HTTP requests to the load balancer on port 80 will be redirected to HTTPS on port 443
        /// </summary>
        [JsonProperty("redirect_http_to_https")]
        public bool RedirectHttpToHttps { get; set; } = false;

        /// <summary>
        /// A boolean value indicating whether PROXY Protocol is in use
        /// </summary>
        [JsonProperty("enable_proxy_protocol")]
        public bool EnableProxyProtocol { get; set; } = false;

        /// <summary>
        /// A boolean value indicating whether HTTP keepalive connections are maintained to target Droplets
        /// </summary>
        [JsonProperty("enable_backend_keepalive")]
        public bool EnableBackendKeepalive { get; set; } = false;

        /// <summary>
        /// A string specifying the UUID of the VPC to which the load balancer is assigned
        /// </summary>
        [JsonProperty("vpc_uuid")]
        public string VpcUuid { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the project that the load balancer is associated with. If no ID is provided at creation, the load balancer associates with the user's default project
        /// </summary>
        [JsonProperty("project_id")]
        public string ProjectId { get; set; } = string.Empty;

        /// <summary>
        /// A boolean value indicating whether to disable automatic DNS record creation for Let's Encrypt certificates that are added to the load balancer
        /// </summary>
        [JsonProperty("disable_lets_encrypt_dns_records")]
        public bool DisableLetsEncryptDnsRecords { get; set; } = false;

        /// <summary>
        /// An integer value which configures the idle timeout for HTTP requests to the target droplets
        /// </summary>
        [JsonProperty("http_idle_timeout_seconds")]
        public int HttpIdleTimeoutSeconds { get; set; } = 0;
    }

    public class ForwardingRule
    {
        [JsonProperty("entry_protocol")]
        public string EntryProtocol { get; set; } = string.Empty;

        [JsonProperty("entry_port")]
        public int EntryPort { get; set; } = 0;

        [JsonProperty("target_protocol")]
        public string TargetProtocol { get; set; } = string.Empty;

        [JsonProperty("target_port")]
        public int TargetPort { get; set; } = 0;

        [JsonProperty("certificate_id")]
        public string CertificateId { get; set; } = string.Empty;

        [JsonProperty("tls_passthrough")]
        public bool TlsPassthrough { get; set; } = false;
    }

    public class HealthCheck
    {
        [JsonProperty("protocol")]
        public string Protocol { get; set; } = string.Empty;

        [JsonProperty("port")]
        public int Port { get; set; } = 0;

        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;

        [JsonProperty("check_interval_seconds")]
        public int CheckIntervalSeconds { get; set; } = 0;

        [JsonProperty("response_timeout_seconds")]
        public int ResponseTimeoutSeconds { get; set; } = 0;

        [JsonProperty("healthy_threshold")]
        public int HealthyThreshold { get; set; } = 0;

        [JsonProperty("unhealthy_threshold")]
        public int UnhealthyThreshold { get; set; } = 0;
    }

    public class StickySessions
    {
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
    }
}
