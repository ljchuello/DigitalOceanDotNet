using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace DigitalOceanDotNet.Objets.LoadBalancer
{
    public class LoadBalancer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("size_unit")]
        public long SizeUnit { get; set; }

        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("forwarding_rules")]
        public List<ForwardingRule> ForwardingRules { get; set; }

        [JsonProperty("health_check")]
        public HealthCheck HealthCheck { get; set; }

        [JsonProperty("sticky_sessions")]
        public StickySessions StickySessions { get; set; }

        [JsonProperty("region")]
        public Region.Region Region { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; } = string.Empty;

        [JsonProperty("droplet_ids")]
        public List<long> DropletIds { get; set; } = new List<long>();

        [JsonProperty("redirect_http_to_https")]
        public bool RedirectHttpToHttps { get; set; } = false;

        [JsonProperty("enable_proxy_protocol")]
        public bool EnableProxyProtocol { get; set; } = false;

        [JsonProperty("enable_backend_keepalive")]
        public bool EnableBackendKeepalive { get; set; } = false;

        [JsonProperty("vpc_uuid")]
        public string VpcUuid { get; set; } = string.Empty;

        [JsonProperty("project_id")]
        public string ProjectId { get; set; } = string.Empty;

        [JsonProperty("disable_lets_encrypt_dns_records")]
        public bool DisableLetsEncryptDnsRecords { get; set; } = false;

        [JsonProperty("http_idle_timeout_seconds")]
        public long HttpIdleTimeoutSeconds { get; set; } = 0;
    }

    public class ForwardingRule
    {
        [JsonProperty("entry_protocol")]
        public string EntryProtocol { get; set; } = string.Empty;

        [JsonProperty("entry_port")]
        public long EntryPort { get; set; } = 0;

        [JsonProperty("target_protocol")]
        public string TargetProtocol { get; set; } = string.Empty;

        [JsonProperty("target_port")]
        public long TargetPort { get; set; } = 0;

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
        public long Port { get; set; } = 0;

        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;

        [JsonProperty("check_longerval_seconds")]
        public long ChecklongervalSeconds { get; set; } = 0;

        [JsonProperty("response_timeout_seconds")]
        public long ResponseTimeoutSeconds { get; set; } = 0;

        [JsonProperty("healthy_threshold")]
        public long HealthyThreshold { get; set; } = 0;

        [JsonProperty("unhealthy_threshold")]
        public long UnhealthyThreshold { get; set; } = 0;
    }

    public class StickySessions
    {
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
    }
}
