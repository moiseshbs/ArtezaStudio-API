using System.Text.Json;
using Confluent.Kafka;

namespace ArtezaStudio.Api.Services.Kafka
{
    public class KafkaProducerService
    {
        private readonly string _bootstrapServers = "localhost:9092";

        public async Task PublicarEventoAsync<T>(string topic, T evento)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers,
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            var jsonMessage = JsonSerializer.Serialize(evento);

            try
            {
                var result = await producer.ProduceAsync(
                    topic,
                    new Message<Null, string> { Value = jsonMessage }
                );

                Console.WriteLine($"Mensagem enviada para o tópico '{topic}'. Offset: {result.Offset}");
            }
            catch (ProduceException<Null, string> ex)
            {
                Console.WriteLine($"Falha ao produzir a mensagem: {ex.Error.Reason}");
            }
            finally
            {
                producer.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}
