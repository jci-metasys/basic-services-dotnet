using System;
using System.Collections;
using System.Diagnostics;
using System.Security.Policy;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// A Metasys Activity Identifier
    /// </summary>
    /// <remarks>
    /// An ActivityId uniquely identifies one audit or one alarm in the system
    ///
    /// Wherever an ActivityId is required you can pass a string instead.
    ///
    /// This is because this is just a token type to signify that an activity identifier is required.
    /// As such it has implicit conversions to/from string.
    /// </remarks>
    public record struct ActivityId(string Value) : IEquatable<ActivityId>, IEquatable<string>, IEquatable<Guid>
    {

        /// <summary>
        /// Creates a default instance of <see cref="ActivityId"/> that is synonymous
        /// with an empty string.
        /// </summary>
        public ActivityId() : this("")
        {

        }

        /// <summary>
        /// Implicitly convert an <see cref="ActivityId"/> to <see cref="string"/>
        /// </summary>
        /// <param name="activityId"></param>
        public static implicit operator string(ActivityId activityId)
        {
            return activityId.Value;
        }

        /// <summary>
        /// Implicitly convert a <see cref="string"/> to <see cref="ActivityId"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ActivityId(string value)
        {
            return new ActivityId(value);
        }

        /// <summary>
        /// Implicitly convert a <see cref="Guid"/> to <see cref="ActivityId"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ActivityId(Guid value)
        {
            return new ActivityId(value.ToString());
        }

        /// <summary>
        /// <s>Implicitly convert a <see cref="ActivityId"/> to <see cref="Guid"/></s>
        /// </summary>
        /// <remarks>
        /// <b>This method is deprecated.</b> This method is not guaranteed to always succeed
        /// in the future. While Metasys activity identifiers have always safely converted to Guids
        /// they make no guarantee that they will always. Nor does the REST API spec document
        /// them as Guids.
        /// <para>
        /// To avoid issues, use methods from this library that take an <see cref="ActivityId"/> for
        /// alarm or audit identifiers. You can even pass strings to those methods as strings will implicitly
        /// convert to ActivityId.
        /// </para>
        /// </remarks>
        /// <param name="activityId"></param>
        // As of writing this should never throw as Metasys currently uses
        // guids for identifiers. But it doesn't advertise this and doesn't
        // guarantee it. Which is why the Guid operators have been deprecated
        // and why this class was created.
        // This operator is as safe as using Guids in all of the demo apps
        // today. Any one of them could throw if an activity id was goofed up.
        [Obsolete("This is not guaranteed to always succeed. Please use methods that use strings or ActivityIds for activity identifiers instead.")]
        public static implicit operator Guid(ActivityId activityId)
        {
            if (Guid.TryParse(activityId, out Guid value))
            {
                return value;
            }

            throw new ArgumentOutOfRangeException(nameof(activityId), "Value must contain a valid guid.");
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            return Value;
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public bool Equals(ActivityId other)
        {
            return Value == other.Value;
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public bool Equals(string other)
        {
            return Value == other;
        }

        /// <inheritdoc cref="object.Equals(object)"/>
        public bool Equals(Guid other)
        {
            return other.ToString() == Value;
        }

    }
}
