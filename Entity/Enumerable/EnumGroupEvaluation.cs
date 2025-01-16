using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enumerable
{
    /// <summary>
    /// Agrupacion de items a evaluar
    /// </summary>
    public enum EnumGroupEvaluation
    {
        /// <summary>
        /// Físico: Se centra en las capacidades fisiológicas y biomecánicas del atleta.
        /// </summary>
        Physical,
        /// <summary>
        /// Técnico: Involucra las habilidades específicas requeridas por el deporte.
        /// </summary>
        Technical,
        /// <summary>
        /// Táctico: Relacionado con la toma de decisiones y estrategias en el contexto del deporte.
        /// </summary>
        Tactical,
        /// <summary>
        /// Mental: Aspectos psicológicos que afectan el desempeño.
        /// </summary>
        Mental,
        /// <summary>
        /// Contextual: Factores externos o situacionales que influyen en el desempeño.
        /// </summary>
        Contextual,
        /// <summary>
        /// Grupales: Algunos deportes pueden clasificarse adicionalmente según si el rendimiento depende de un equipo o de un único atleta:
        /// </summary>
        Groups,
        /// <summary>
        /// Individuales: Algunos deportes pueden clasificarse adicionalmente según si el rendimiento depende de un equipo o de un único atleta:
        /// </summary>
        Individuals
    }
}
